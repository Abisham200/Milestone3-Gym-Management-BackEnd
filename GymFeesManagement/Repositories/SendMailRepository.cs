using GymFeesManagement.Database;
using GymFeesManagement.Entities;
using GymFeesManagement.Enum;
using Microsoft.EntityFrameworkCore;

namespace GymFeesManagement.Repositories
{
    public class SendMailRepository(AppDbContext _Context)
    {
        public async Task<EmailTemplate> GetTemplate(EmailTypes emailTypes)
        {
            var template = _Context.EmailTemplates.Where(x => x.emailTypes == emailTypes).FirstOrDefault();
            return template;
        }
    }
}
