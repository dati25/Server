using Quartz;
using Server.Database.Models;
using Server.Services.QuartzClasses;
using System.Data;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Server.Services.QuartzService
{
    public class ScheduleService
    {
        MyContext context = new();
        public async Task<IHost> ScheduleAll()
        {
            var builder = this.GetBuilder();
            var scheduler = await this.GetScheduler(builder);

            var job = JobBuilder.Create<MailJob>()
                    .WithIdentity("EmailJob", "EmailJobs")
                    .StoreDurably()
                    .Build();
            await scheduler.AddJob(job, true);

            this.context.Admins!.ToList().ForEach(admin =>
            {
                scheduler.ScheduleJob(this.GenerateTrigger(admin, job));
            });

            await scheduler.Start();
            return builder;
        }
        public async Task RescheduleJob(Admin admin)
        {
            var scheduler = await this.GetScheduler(null);
            var job = await this.GetJob(scheduler) ?? throw new NoNullAllowedException();
            await scheduler!.RescheduleJob(this.GetAdminTriggerKey(admin), this.GenerateTrigger(admin, job));
        }
        public async Task UnscheduleJob(Admin admin)
        {
            var scheduler = await this.GetScheduler(null);
            await scheduler!.UnscheduleJob(this.GetAdminTriggerKey(admin));
        }
        public async Task ScheduleJob(Admin admin)
        {
            var scheduler = await this.GetScheduler(null);
            var job = await this.GetJob(scheduler) ?? throw new NoNullAllowedException();
            await scheduler!.ScheduleJob(this.GenerateTrigger(admin, job));
        }
        private IHost GetBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
            .ConfigureServices((cxt, services) =>
            {
                services.AddQuartz(q =>
                {
                    q.UseMicrosoftDependencyInjectionJobFactory();
                });
                services.AddQuartzHostedService(opt =>
                {
                    opt.WaitForJobsToComplete = true;
                });
            }).Build();
            return builder;
        }
        private ITrigger GenerateTrigger(Admin admin, IJobDetail job)
        {
            return TriggerBuilder.Create()
                .WithIdentity($"Admin({admin.Id})", "MailTriggers")
                .UsingJobData(new JobDataMap(new Dictionary<string, Admin> { { "admin", admin } }))
                .WithCronSchedule("0 " + admin.RepeatPeriod)
                .ForJob(job)
                .Build();
        }
        private async Task<ITrigger?> GetTrigger(Admin admin)
        {
            var scheduler = await this.GetScheduler(null);
            return await scheduler!.GetTrigger(this.GetAdminTriggerKey(admin));
        }
        private TriggerKey GetAdminTriggerKey(Admin admin)
        {
            return new TriggerKey($"Admin({admin.Id})", "MailTriggers");
        }
        private async Task<IJobDetail?> GetJob(IScheduler scheduler)
        {
            var jobKey = new JobKey("EmailJob", "EmailJobs");
            return await scheduler!.GetJobDetail(jobKey);
        }
        private async Task<IScheduler> GetScheduler(IHost? builder)
        {
            builder = builder ?? this.GetBuilder();
            var schedFactory = builder.Services.GetService<ISchedulerFactory>();
            return await schedFactory!.GetScheduler();
        }
    }
}
