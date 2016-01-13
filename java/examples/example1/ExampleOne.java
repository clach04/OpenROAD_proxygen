/**
 * Copyright Luminary Solutions Limited
 *
 */
import java.util.HashMap;
import com.ca.openroad.*;
import uk.co.luminary.proxygen.util.*;
import uk.co.luminary.proxygen.examples.example1.Proxy;

/**
 * <!-- ----------------------------------------------------------------------------------------- -->
 * <pre>
 * Description     : A simple example of using ProxyGen's generated code to talk to an OpenROAD
 *                   application.
 *
 * <!--
 * Class           : ExampleOne
 * System Name     : ProxyGen
 * Sub-System Name : Java Example 1
 *
 * Version History
 *
 * Version  Date        Who     Description
 * -------  ----------- -----   -----------
 * 1.0      02-04-2008  AGS     Original version.
 * </pre>
 * -->
 * @author Anthony Simpson    (Luminary Solutions)
 * @version Revision $Revision$ created on $Date$ by $Author$
 *
 * <!-- ----------------------------------------------------------------------------------------- -->
 */
public class ExampleOne
{
    /**
     * <!-- ------------------------------------------------------------------------------------- -->
     * <!--
     * Method Name : main
     * -->
     * <pre>
     * Description : Program entry point. Expect no arguments (but doesn't check). Will connect to
     *               an OpenRoad Example appliction, call some methods and print the results then
     *               exit (See README.TXT).
     *
     * @param argv command line arguments
     * @throws Exception
     * </pre>
     * <!-- ------------------------------------------------------------------------------------- -->
     */
    public static void main(String argv[]) throws Exception
    {
        ASOSession aso = new ASOSession();
        HashMap params = new HashMap(); //Will be used to pass parameters to and from each SCP
        try
        {
            //Connect to the Application server
            aso.connect("Example1", null, null);

            //Initialise the generated proxy object
            Proxy proxy = new Proxy(aso);

            params.put("b_v_test", "");
            proxy.helloWorld(params);
            System.out.println("Called SCP_HelloWorld got: \"" +
                                                            (String)params.get("b_v_test") + "\"");

            //You can reuse the params object because SCP_Capitalise takes the same parameters as
            //SCP_HelloWorld
            proxy.capitalise(params);
            System.out.println("Called SCP_Capitalise with SCP_HelloWorld result got: \"" +
                                                            (String)params.get("b_v_test") + "\"");

             //set params for call to swap
            params.clear();
            params.put("b_v_test1", "String 1");
            params.put("b_v_test2", "String 2");
            proxy.swap(params);
            System.out.println("Called SCP_Swap with \"String 1\" and \"String 2\" got: \"" +
                                                   (String)params.get("b_v_test1") + "\" and \""  +
                                                           (String)params.get("b_v_test2") + "\"");
        }
        finally
        {
            aso.disconnect();
        }
    }
}
