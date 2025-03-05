using WinformsDemo.BusinessLogic;

namespace WinformsDemo.UI
{
    public class MyButton
    {   
        private ICommand _command;
        public void ExecuteCommand()
        {
            _command.Execute();
        }

        public void SetCommand(ICommand command)
        {
            this._command = command;
        }

        public void DesignUI(string details)
        {
            //UI code goes here
        }
    }
}
