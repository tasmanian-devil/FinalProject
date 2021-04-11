using draft.Test;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKFinalProjectVCS.Test
{
    public class RegilaSignUpTest : BaseTest
    {
        [Test]
        public static void PressSignUpButtonWithEmptyInputFieldsTest()
        {
            _signUpPage.NavigateToPage()
                .PressSignUpButton();
                //.VerifyNameDetailsRequiredFeedbackMessage();
        }
    } 
}
