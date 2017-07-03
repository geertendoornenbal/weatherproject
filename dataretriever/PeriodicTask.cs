using System;
using System.Threading;
using System.Threading.Tasks;

public class PeriodicTask
{
  private Action mAction;
  private CancellationToken mCancellationToken;

  public PeriodicTask(Action aAction, CancellationToken aCancellationToken)
  {
    mAction = aAction;
    mCancellationToken = aCancellationToken;
  }

  public async Task Run(TimeSpan aPeriod)
  {
    while(!mCancellationToken.IsCancellationRequested)
    {
      await Task.Delay(aPeriod, mCancellationToken);

      if (!mCancellationToken.IsCancellationRequested)
      {
        mAction();
      }    
    }
  }
}