using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_MVP.Presenters;

namespace test_MVP.Views
{
    public interface IDetailsPage
    {
        void UpdateValues(string name,string age,string gender);
        void AttachPresenter(IDetailsPageViewObserver presenter);
        void ClearValues();
    }
    public partial class DetailsPage : UserControl,IDetailsPage
    {
        private IDetailsPageViewObserver presenter;
        public DetailsPage()
        {
            InitializeComponent();
        }

        public void AttachPresenter(IDetailsPageViewObserver presenter)
        {
            this.presenter = presenter;   
        }

        public void ClearValues()
        {
            txtName.Text =
            txtAge.Text =
            txtGender.Text = "";
        }

        public void UpdateValues(string name,string age,string gender)
        {
            txtName.Text = name;
            txtAge.Text = age;
            txtGender.Text = gender;
        }
    }
}
