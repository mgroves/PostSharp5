using System;
using System.Collections.Generic;

namespace Auth
{
    public interface IGovtFormService
    {
        void SubmitForm(GovtForm form);
        IEnumerable<GovtForm> GetAllForms();
        GovtForm GetFormById(Guid guid);
    }
}