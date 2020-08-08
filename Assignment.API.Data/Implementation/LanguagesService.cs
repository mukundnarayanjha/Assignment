using Assignment.API.Common.Repository;
using Assignment.API.Models;
using Assignment.API.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Data.Interface
{
    public class LanguagesService : RepositoryBase<Language>, ILanguagesService
    {
        public LanguagesService(AssignmentDBContext context) : base(context)
        { }
        public async Task<IEnumerable<Language>> GetAllLanguageAsync()
        {
            var languages = await FindAllAsync();
            return languages.OrderBy(x => x.Name);
        }
    }
}
