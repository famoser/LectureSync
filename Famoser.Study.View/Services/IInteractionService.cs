using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.Study.View.Services
{
    public interface IInteractionService
    {
        void OpenInBrowser(Uri uri);
        void CheckBeginInvokeOnUi(Action action);
    }
}
