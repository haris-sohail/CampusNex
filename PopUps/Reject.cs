/*
 *              CAMPUSNEX POPUP CLASSES: Reject.cs
 *              
 *              Coded By ACECODERS:
 *              
 *                      -> Kalsoom Tariq (i21-2487)
 *                      -> Haris Sohail (i21-0531)
 *                      -> Aiman Safdar (i21-0588)
 *                      
 */
using CampusNex.Model;
using System;
using System.Windows.Forms;

namespace CampusNex.PopUps
{
    public partial class Reject : Form
    {

        // Handler to Send Data Back To Controller
        public event DataSentEventHandler DataSent;
        // Unique Data Members for each Rejection
        private string type;
        public Society sr = new Society();
        public Event er = new Event();
        public int mId;

        // Constructor
        public Reject(string type)
        {
            this.type = type;
            InitializeComponent();
        }

        // Dismiss Button
        private void btnDismiss_Click(object sender, EventArgs e)
        {
            DataSent?.Invoke(this, new DataSentEventArgs(false, -1));
            this.Close();
        }

        // Reject Logic
        private void rejectButton_Click(object sender, EventArgs e)
        {
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