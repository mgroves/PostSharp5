using System;

namespace Auth
{
    public class GovtForm
    {
        public GovtForm()
        {
            FormId = Guid.NewGuid();
        }
        public Guid FormId { get; private set; }
        public string UserName { get; set; }
        public string FormInformation { get; set; }
    }
}