using draft.Test;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using draft.Page;

namespace IKFinalProjectVCS.Test
{
    public class RegilaLoginTest : BaseTest
    {   
        [TestCase("test@test.com", "testas", TestName = "Login with wrong details feedback test")]
        public static void VerifyFeedbackWhenWronLoginDetailsEntered(string email, string pass) 
        {
            _loginPage.NavigateToPage()
            .InsertEmail(email)
            .InsertPass(pass)
            .PressLogin()
            .VerifyWrongDetailsFeedbackMessage();
        }
    }
}
