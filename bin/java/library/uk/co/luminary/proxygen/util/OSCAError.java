/**
 * Copyright Luminary Solutions Limited
 *
 */
package uk.co.luminary.proxygen.util;

/**
 * <!-- ----------------------------------------------------------------------------------------- -->
 * <pre>
 * Description     : An abtract superclass for exceptions thrown on an error from OpenROAD. The
 *                   exceptions message is set to the message returned from OpenROAD and there is
 *                   a method to get the error number.
 * <!--
 * Class           : uk.co.luminary.proxygen.util.OSCAError
 * System Name     : ProxyGen
 * Sub-System Name : Java Template Code
 *
 * Version History
 *
 * Version  Date        Who     Description
 * -------  ----------- -----   -----------
 * 1.0      03-04-2008  AGS     Original version.
 * </pre>
 * -->
 * @author Anthony Simpson    (Luminary - An Ingres Company)
 * @version Revision $Revision$ created on $Date$ by $Author$
 *
 * <!-- ----------------------------------------------------------------------------------------- -->
 */
public abstract class OSCAError extends Exception
{
    /**
     * <code>FATAL</code> : Fatal error type from OpenROAD.
     */
    public static final int FATAL_ERROR_TYPE = 1;
    /**
     * <code>USER</code> : User error type from OpenROAD.
     */
    public static final int USER_ERROR_TYPE  = 2;
    /**
     * <code>INFO</code> : Info error type from OpenROAD.
     */
    public static final int INFO_ERROR_TYPE  = 3;

    private int errorNumber;

    /**
     * <!-- ------------------------------------------------------------------------------------- -->
     * <!--
     * Method Name : OCAError
     * -->
     * <pre>
     * Description : Constructor.
     *
     * @param errorNumber The error number returned by OpenROAD
     * @param errorMessage The error message returned by OpenROAD
     * </pre>
     * <!-- ------------------------------------------------------------------------------------- -->
     */
    public OSCAError(int errorNumber, String errorMessage)
    {
        super(errorMessage);
        this.errorNumber = errorNumber;
    }

    /**
     * <!-- ------------------------------------------------------------------------------------- -->
     * <!--
     * Method Name : getErrorNumber
     * -->
     * <pre>
     * Description : Get the OpenRoad Error number which cause this exception.
     *
     * @return The error number from OpenROAD
     * </pre>
     * <!-- ------------------------------------------------------------------------------------- -->
     */
    public int getErrorNumber()
    {
        return this.errorNumber;
    }
}
