using Android.App;
using Android.Widget;
using Android.OS;

namespace FirstAndroidApplication1
{
    // The Activity attribute applies to the class (MainActivity). The
    // Label appears on the application's title bar. The MainLauncher=true
    // causes the activity to operate as the startup activity.
    [Activity(Label = "FirstAndroidApplication", MainLauncher = true, 
        Icon = "@drawable/icon")]

    // Activities derive from the Activity class.
    public class MainActivity : Activity
    {
        private CheckBox chkDelegate;

        // The OnCreate event fires when the activity is created by
        // Android. 
        protected override void OnCreate(Bundle bundle)
        {
            // First call the base class method and pass the bundle to it.
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource.
            // this must be done before trying to reference any of the 
            // widgets.
            SetContentView (Resource.Layout.Main);

            // A TextView control named txtDateOutput appears in the Main.axml file.
            // So you can use Resource.Id.txtDateOutput to get a reference to the widget
            TextView txt = (TextView)FindViewById(Resource.Id.txtDateOutput);
            txt.Text = System.DateTime.Now.ToString();

            // Buttons to demonstrate the three different ways to register an event handler.
            Button btnDelegate = (Button)FindViewById(Resource.Id.btnDelegate);
            Button btnAnonymousDelegate = (Button)FindViewById(Resource.Id.btnAnonymousDelegate);
            Button btnLambda = (Button)FindViewById(Resource.Id.btnLambda);

            Button btnSquareValue = (Button)FindViewById(Resource.Id.btnSquareValue);
            btnSquareValue.Click += btnSquareValue_Click;

            chkDelegate = (CheckBox)FindViewById(Resource.Id.chkDelegate);

            // Register the Click event handler for the button named btnDelegate.
            // The delegate points to the procedure named btnDelegate_Click. The
            // procedure name is not signficant. So long as the names match, the
            // event handler will work.
            btnDelegate.Click += btnDelegate_Click;

            chkDelegate.Click += chkDelegate_Click;

            // Register the Click event handler for the button named btnAnonymousDelegate.
            // Here, we are using the anonymous delegate technique. Instead of having
            // a named procedure, the procedure code block follows the delegate
            // keyword.
            btnAnonymousDelegate.Click += delegate
            {
                txt.Text = System.DateTime.Now.ToString();
            };

            // Register the Click event handler for the button named btnLambda.
            // Here, we are using the lambda expression technique. The event arguments
            // appear on the left side of the lambda expression. The code block appears
            // on the right side. The code looks just like the code for the anonymous
            // method.
            btnLambda.Click += (sender, args) => 
                { txt.Text = System.DateTime.Now.ToString(); };
        }

        // Event handler for the delegate. The first argument to an event handler is
        // always named sender and has a type of System.object. The second argument
        // always has a type of System.EventArgs or a class that derives from
        // System.EventArgs.
        void btnDelegate_Click(object sender, System.EventArgs args)
        {
            TextView txt = (TextView)FindViewById(Resource.Id.txtDateOutput);
            txt.Text = System.DateTime.Now.ToString();
        }

        void chkDelegate_CheckedChange(object sender, System.EventArgs args)
        {
            TextView txt = (TextView)FindViewById(Resource.Id.txtDateOutput);
            txt.Text = System.DateTime.Now.ToString() + "CheckedChange";
        }

        void chkDelegate_Click(object sender, System.EventArgs args)
        {
            TextView txt = (TextView)FindViewById(Resource.Id.txtDateOutput);


            if (chkDelegate.Checked)
            {
                txt.Text = System.DateTime.Now.ToString() + " Click Checked";
            }
            else
            {
                txt.Text = System.DateTime.Now.ToString() + " Click Unchecked";
            }
        }

        // Button Click event handler to square input.
        void btnSquareValue_Click(object sender, System.EventArgs args)
        {
            // Get the widget references.
            EditText etNumberIn = (EditText)FindViewById(Resource.Id.etNumberIn);
            TextView txtNumberOut = (TextView)FindViewById(Resource.Id.txtNumberOut);

            double inputConverted;

            // Convert the input to a number.
            inputConverted = System.Convert.ToDouble(etNumberIn.Text);

            // Square the number. Convert the result to a String, and display
            // the output.
            txtNumberOut.Text = (inputConverted * inputConverted).ToString();
        }
    }
}
// 120

