using System.Windows.Forms;

namespace WindowsFormsApp {
    public partial class NotificationForm : Form, IHandler<UserCreateProgressedModel>, IHandler<UserCreateCompleteModel> {
        public NotificationForm() {
            InitializeComponent();
            MessageBus.Instance.RegisterHandler(this);
            this.FormClosing += (sender, args) => MessageBus.Instance.RemoveHanler(this);
        }

        public void Handle(UserCreateProgressedModel model) {
            if (!string.IsNullOrEmpty(dataLabel.Text)) {
                dataLabel.Text = "";
            }
            progressLabel.Text = model.Percentage + " %";
            Application.DoEvents();
        }

        public void Handle(UserCreateCompleteModel model) {
            progressLabel.Text = "完了";
            dataLabel.Text = model.UserId;
        }
    }
}
