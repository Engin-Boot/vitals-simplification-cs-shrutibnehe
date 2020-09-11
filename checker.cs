using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalsCheker
{
    public abstract class Alert
    {
        internal abstract void raiseAlert(string vitalname, string message);

    }
    internal class SMSAlert : Alert
    {

        internal override void raiseAlert(string vitalname, string message)
        {
            Console.WriteLine("SMS Alert "+vitalname + " is " + message);
        }
    }
    internal class SoundAlert : Alert
    {

        internal override void raiseAlert(string vitalname, string message)
        {
            Console.WriteLine("Sound Alert "+vitalname + " is " + message);
        }
    }
   public class vitals
    {
        int upperLimit;
        int lowerLimit;
        string vitalName;
     public vitals(string vitalName, int upperLimit, int lowerLimit)
        {
            this.vitalName = vitalName;
            this.upperLimit = upperLimit;
            this.lowerLimit = lowerLimit;
        }
     public void checkVitalIsOk(Alert alert, int vitalvalue)
        {
            
            if (vitalvalue > this.upperLimit)
            {
                alert.raiseAlert(vitalName, "HIGH");
            }
            else if (vitalvalue < this.lowerLimit)
            {
                alert.raiseAlert(vitalName, "LOW");
            }
            else
            {
                alert.raiseAlert(vitalName, "NORMAL");
            }
        }

    }


    public class Checker
    {
    
    static int Main(string[] args)
    {
        vitals vital1 = new vitals("BPM", 150, 70);
        vitals vital2 = new vitals("SPO2", 100, 90);
        vitals vital3 = new vitals("RespRate", 90, 30);

        SMSAlert smsalert = new SMSAlert();
        SoundAlert soundalert = new SoundAlert();
           
        vital1.checkVitalIsOk(smsalert, 85);
        vital1.checkVitalIsOk(soundalert, 60);
        vital3.checkVitalIsOk(soundalert, 95);
        vital2.checkVitalIsOk(smsalert, 95);
        vital2.checkVitalIsOk(smsalert, 85);
        vital3.checkVitalIsOk(smsalert, 70);
        vital3.checkVitalIsOk(soundalert, 100);
        return 0;
    }

  }
}
