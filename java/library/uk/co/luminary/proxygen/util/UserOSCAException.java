/**
 * Copyright Luminary Solutions Limited
 *
 */
package uk.co.luminary.proxygen.util;

/**
 * <!-- ----------------------------------------------------------------------------------------- -->
 * <pre>
 * Description     : A user exception from OpenROAD.
 * <!--
 * Class           : uk.co.luminary.proxygen.util.UserOSCAException
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
public class UserOSCAException extends OSCAError
{
    public UserOSCAException(int errorNumber, String errorMessage)
    {
        super(errorNumber, errorMessage);
    }
}
