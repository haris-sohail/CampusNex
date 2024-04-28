using CampusNex.Model;
using System;
using System.Windows.Forms;

namespace CampusNex.PopUps
{
    public partial class Reject : Form
    {

        // To Send Back Data
        public event DataSentEventHandler DataSent;
        // 3 Rejections
        // Society rejection
        private string type;
        public Society sr = new Society();
        public Event er = new Event();
        public int mId;

        public Reject(string type)
        {
            this.type = type;
            InitializeComponent();
        }

        private void btnDismiss_Click(object sender, EventArgs e)
        {

            DataSent?.Invoke(this, new DataSentEventArgs(false, -1));
            this.Close();
        }
        private void rejectButton_Click(object sender, EventArgs e)
        {
            // Event reject Logic
            if (type == "Event")
            {
                er.rejectEvent(rejectReason.Text);
                DataSent?.Invoke(this, new DataSentEventArgs(true, er.EventId));
            }
            else if (type == "Society")
            {
                sr.rejectSociety(rejectReason.Text);
                DataSent?.Invoke(this, new DataSentEventArgs(true, sr.SocietyId));
            }
            else if (type == "Member")
            {
                Member.rejectMember(mId, rejectReason.Text);
            }
            this.Close();
        }
    }
}

// A Delegate Event Handler
public delegate void DataSentEventHandler(object sender, DataSentEventArgs e);
public class DataSentEventArgs : EventArgs
{
    public Boolean Status { get; }
    public int Id { get; }

    public DataSentEventArgs(Boolean data, int id)
    {
        Status = data;
        Id = id;
    }
}