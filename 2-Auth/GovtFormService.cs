using System;
using System.Collections.Generic;
using System.Linq;

namespace Auth
{
    public class GovtFormService : IGovtFormService
    {
        private static readonly IList<GovtForm> _govtFormsDatabase = new List<GovtForm>();

        public GovtFormService()
        {
            // build up some initial entries with a variety of usernames
            _govtFormsDatabase.Add(new GovtForm { FormInformation = "details for a form submitted by mgroves", UserName = "mgroves"});
            _govtFormsDatabase.Add(new GovtForm { FormInformation = "steve smith's form details", UserName = "ssmith"});
            _govtFormsDatabase.Add(new GovtForm { FormInformation = "text of Susie Q's form information and details", UserName = "susieq"});
            _govtFormsDatabase.Add(new GovtForm { FormInformation = "Walter Mathau's form information details", UserName = "wmathau" });
            _govtFormsDatabase.Add(new GovtForm { FormInformation = "Ali Groves's form information details", UserName = "agroves" });
        }

        public void SubmitForm(GovtForm form)
        {
            _govtFormsDatabase.Add(form);
        }

        [Caching]
        [AuthorizeReturnValue]
        public IEnumerable<GovtForm> GetAllForms()
        {
            return _govtFormsDatabase;
        }

        //[AuthorizeReturnValue]
        public GovtForm GetFormById(Guid guid)
        {
            return _govtFormsDatabase.FirstOrDefault(form => form.FormId == guid);
        }
    }
}