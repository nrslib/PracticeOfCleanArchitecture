using System;
using System.Windows.Forms;
using ClArc.Sync;
using UseCase.Users.Create;

namespace WindowsFormsApp {
    public partial class Form1 : Form, IHandler<UserCreateCompleteModel> {
        private readonly UseCaseBus bus;
        private int id;
        public Form1(UseCaseBus bus) {
            this.bus = bus;
            InitializeComponent();
            MessageBus.Instance.RegisterHandler(this);
        }

        private void openPresenterButton_Click(object sender, EventArgs e) {
            var form = new NotificationForm();
            form.Show();
        }

        private void createUserButton_Click(object sender, EventArgs e) {
            createUserButton.Enabled = false;
            var request = new UserCreateRequest("user" + id++);
            bus.Handle(request);
        }

        public void Handle(UserCreateCompleteModel model) {
            createUserButton.Enabled = true;
        }
    }
}
