using System;
using System.Windows.Forms;

namespace WinShutServer
{
    public partial class SequenceFrame : Form
    {

        private RadioButton[] sequence = new RadioButton[6];
        private RadioButton[] type = new RadioButton[3];

        public SequenceFrame()
        {
            InitializeComponent();
        }

        public void RunOnUIThread(Action func)
        {
            if (!IsDisposed)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        if (!IsDisposed)
                        {
                            func();
                        }
                    }));
                    return;
                }
                func();
            }
        }

        private void b_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SequenceFrame_Load(object sender, EventArgs e)
        {

            sequence[0] = rs_shutdown;
            sequence[1] = rs_restart;
            sequence[2] = rs_sleep;
            sequence[3] = rs_hibernate;
            sequence[4] = rs_logoff;
            sequence[5] = rs_lockuser;

            type[0] = rt_fast;
            type[1] = rt_timed;
            type[2] = rt_scheduled;

            OnSequenceChange(
                new Utils.SequenceChangeEventArgs(
                    Utils.Sequence.CurrentSequence, 
                    Utils.Sequence.CurrentType));

            Utils.Sequence.SequenceChange += OnSequenceChange;
            
        }

        private void OnSequenceChange(Utils.SequenceChangeEventArgs args)
        {
            RunOnUIThread(() =>
            {

                bool _no = args.Sequence == Utils.SequenceList.NoShutdown;

                b_set.Enabled = _no;
                b_cancel.Enabled = !_no;

                foreach (RadioButton s in sequence)
                {
                    s.Enabled = _no;
                    s.Checked = false;
                }
                foreach (RadioButton t in type)
                {
                    t.Enabled = _no;
                    t.Checked = false;
                }
                

                sequence[0].Checked = _no;
                type[0].Checked = _no;

                if (!_no)
                {
                    int _seq = (int)args.Sequence - 1;
                    int _type = (int)args.Type - 1;
                    sequence[_seq].Checked = true;
                    type[_type].Checked = true;
                    n_hour.Value = args.Hour;
                    n_minute.Value = args.Minute;
                    n_second.Value = args.Second;
                }

                n_hour.Enabled = _no;
                n_minute.Enabled = _no;
                n_second.Enabled = _no;

                l_current.ForeColor = Utils.Sequence.GetColor(args.Sequence);
                l_current.Text = args.ToString();
            });
        }

        private void SequenceFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.Sequence.SequenceChange -= OnSequenceChange;
        }

        private void rt_fast_CheckedChanged(object sender, EventArgs e)
        {
            n_hour.Enabled = !rt_fast.Checked;
            n_minute.Enabled = !rt_fast.Checked;
            n_second.Enabled = !rt_fast.Checked;
        }

        private void rt_timed_CheckedChanged(object sender, EventArgs e)
        {
            n_hour.Enabled = !rt_fast.Checked;
            n_minute.Enabled = !rt_fast.Checked;
            n_second.Enabled = !rt_fast.Checked;
        }

        private void rt_scheduled_CheckedChanged(object sender, EventArgs e)
        {
            n_hour.Enabled = !rt_fast.Checked;
            n_minute.Enabled = !rt_fast.Checked;
            n_second.Enabled = !rt_fast.Checked;
        }

        private void b_set_Click(object sender, EventArgs e)
        {
            int _seq;
            for(_seq = 1; _seq <= sequence.Length; ++_seq)
            {
                if (sequence[_seq - 1].Checked) break;
            }

            int _type;
            for(_type = 1; _type <= type.Length; ++_type)
            {
                if (type[_type - 1].Checked) break;
            }
            
            switch((Utils.SequenceType)_type)
            {
                case Utils.SequenceType.Fast:
                    Utils.Sequence.Set(_seq);
                    break;
                case Utils.SequenceType.Timed:
                    Utils.Sequence.Set(_seq, 
                        (int)n_hour.Value, 
                        (int)n_minute.Value, 
                        (int)n_second.Value);
                    break;  
                case Utils.SequenceType.Scheduled:
                    Utils.MyDate md = new Utils.MyDate(
                        (int)n_hour.Value,
                        (int)n_minute.Value,
                        (int)n_second.Value
                        );
                    if(md.Ticks <= DateTime.Now.Ticks)
                    {
                        md = new Utils.MyDate(
                            md.Year,
                            md.Month,
                            md.Day + 1,
                            md.Hour,
                            md.Minute,
                            md.Second
                            );
                    }
                    Utils.Sequence.Set(_seq, md);
                    break;
            }
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            Utils.Sequence.Set(Utils.SequenceList.NoShutdown);
        }
    }
}
