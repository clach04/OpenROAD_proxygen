/**
 * Copyright Luminary Solutions Limited
 *
 */
package uk.co.luminary.proxygen.util;

import java.io.Serializable;

/**
 * <!-- ----------------------------------------------------------------------------------------- -->
 * <pre>
 * Description     : A specialisation of OpenROADDate that represents a date with a time in OpenRoad.
 *                   This class provides no specialised behaviour but instead serves as a marker 
 *                   class to differentiate from dates without a time.
 *
 * <!--
 * Class           : uk.co.luminary.proxygen.util.OpenROADDateTime
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
 * @author Anthony Simpson    (Luminary - an Ingres company)
 * @version Revision $Revision$ created on $Date$ by $Author$
 *
 * <!-- ----------------------------------------------------------------------------------------- -->
 */
public class OpenROADDateTime extends OpenROADDate implements Serializable
{
  
    //<code>serialVersionUID</code> : universal serial identifier for this class
    private static final long serialVersionUID = -1384549730260740770L;

    /**
     * <pre>
     * Description : Creates an <code>OpenROADDateTime</code> instance that represents the date it was allocated.
     *
     * </pre>
     */
    public OpenROADDateTime() 
    {
        super();
    }
    
    
    /**
     * <pre>
     * Description : Creates an <code>OpenROADDateTime</code> instance using the given milliseconds time value.
     *
     * @param date the date in milliseconds since January 1, 1970, 00:00:00 GMT not to exceed the 
     * milliseconds representation for the year 8099. A negative number indicates the number of 
     * milliseconds before January 1, 1970, 00:00:00 GMT.
     * </pre>
     */
    public OpenROADDateTime(final long date)
    {
        super(date);
    }
}
