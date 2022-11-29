using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Timer_Console
{
    class Timer
    {
        TimerCallback _callback;
        object _state;
        int _dueTime;
        int _period;
        public Timer(TimerCallback callback,object state,int dueTime,int period)
        {
            _callback = callback;
            _state = state;
            _dueTime = dueTime;
            _period = period;
        }
        public Timer(TimerCallback callback)
        {
            _callback = callback;
        }
        public void Change(int due,int inf)
        {
            _period = inf;
            _dueTime = due;
        }
    }
}
