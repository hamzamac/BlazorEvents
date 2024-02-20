namespace EventsBroker.Services
{
    public class Counter
    {
        public event EventHandler? CounterChanged;

        protected virtual void OnCounterChanged(EventArgs e)
        {
            CounterChanged?.Invoke(this, e);
        }

        //public delegate void ThresholdReachedEventHandler(object sender, ThresholdReachedEventArgs e){
        //    }

        class ThresholdReachedEventArgs : EventArgs
        {
            public int Value { get; set; }
        }

    }
}
