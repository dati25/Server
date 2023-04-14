﻿using Server.Results.DestinationResults;
using Server.Results.GroupResults;
using Server.Results.SourceResults;
using Server.Results.TaskResults;
using Server.Database.Models;
namespace Server.Commands.ConfigCommands
{
    public class ConfigCommandTest
    {
        public string Type { get; set; }
        public string? RepeatPeriod { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? Compress { get; set; } = false;
        public int? Retention { get; set; }
        public int? PackageSize { get; set; }
        public int CreatedBy { get; set; }
        public bool? Status { get; set; }
        public List<SourceResultPost>? Sources { get; set; }
        public List<DestinationResultPost>? Destinations { get; set; }
        public List<TaskResultPost>? Tasks { get; set; }
        public List<GroupResultConfigPost>? groupIDs { get; set; }
        public ConfigCommandTest(Config config)
        {
            this.Type = config.Type;
            this.RepeatPeriod = config.RepeatPeriod;
            this.ExpirationDate = config.ExpirationDate;
            this.Compress = config.Compress;
            this.Retention = config.Retention;
            this.PackageSize = config.PackageSize;
            this.CreatedBy = config.CreatedBy;
            this.Status = config.Status;
            this.Sources = new List<SourceResultPost>();
            this.Destinations = new List<DestinationResultPost>();
            this.Tasks = new List<TaskResultPost>();

            config.Sources!.ForEach(x => this.Sources!.Add(new SourceResultPost(x.Path)));
            config.Destinations!.ForEach(x => this.Destinations!.Add(new DestinationResultPost(x.Type, x.Path)));
            //config.Tasks!.ForEach(x => this.Tasks!.Add(new TaskResultPost(x.IdPc)));
        }
        public ConfigCommandTest(ConfigCommandPost config)
        {
            this.Type = config.Type;
            this.RepeatPeriod = config.RepeatPeriod;
            this.ExpirationDate = config.ExpirationDate;
            this.Compress = config.Compress;
            this.Retention = config.Retention;
            this.PackageSize = config.PackageSize;
            this.CreatedBy = config.CreatedBy;
            this.Status = config.Status;

            if (config.Sources != null)
            {
                this.Sources = new List<SourceResultPost>();
                config.Sources!.ForEach(x => this.Sources!.Add(new SourceResultPost(x.Path)));
            }
            if (config.Destinations != null)
            {
                this.Destinations = new List<DestinationResultPost>();
                config.Destinations!.ForEach(x => this.Destinations!.Add(new DestinationResultPost(x.Type, x.Path)));
            }
            if (config.Compress != null)
            {
                this.Tasks = new List<TaskResultPost>();
                config.Tasks!.ForEach(x => this.Tasks!.Add(new TaskResultPost(x.IdPc)));
            }
        }
    }
}