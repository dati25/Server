using SeverAPI.Results.AdminResults;
namespace SeverAPI.Commands.AdminsCommands
{
    public class ReportCommandSearchedGet : Command
    {
        //public List<AdminResultGet> Execute(int? id, string? username, string? email)
        //{
        //    AdminCommandGet command = new AdminCommandGet();
        //    List<AdminResultGet> admins = command.Execute(null, default);

        //    admins = id == null ? admins : admins.Where(x => x.id == id).ToList();
        //    admins = username == null ? admins : admins.Where(x => x.Username == username).ToList();
        //    admins = email == null ? admins : admins.Where(x => x.Email == email).ToList();

        //    if (admins == null)
        //        return null!;

        //    return admins;
        //}
        public AdminResultGet Execute(int id)
        {
            AdminResultGet adminResult = new AdminResultGet(context.Admins.Find(id));

            return adminResult;

        }
    }
}
