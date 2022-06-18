using OutManager.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OutManager.ViewModels
{
    public class FuncionarioViewModel : BaseViewModel
    {
        #region Declaration
        public INavigation Navigation { get; set; }
        private string nome;
        #endregion

        #region Implementation
        public string Nome
        {
            get => nome;
            set => SetProperty(ref nome, value);
        }
        #endregion

        public FuncionarioViewModel()
        {
        }
    }
}
