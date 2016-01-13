/**
 * Copyright Luminary Solutions Limited
 *
 */
package uk.co.luminary.proxygen.util;

import java.io.Serializable;
import java.util.Date;

/**
 * <!-- ----------------------------------------------------------------------------------------- -->
 * <pre>
 * Description     : This is a specialisation of a <code>java.util.Date</code> that allows 
 *                   OpenROAD to identify this as a date without a time or as a special blank date.  
 *
 * <!--
 * Class           : uk.co.luminary.proxygen.util.OpenROADDate
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
public class OpenROADDate extends Date implements Serializable
{
    //<code>serialVersionUID</code> : universal serial identifier for this class
    private static final long serialVersionUID = 4600963729129055567L;
    
    // Represents an OpenROAD blank date.
    private static final OpenROADDate BLANK_DATE =
        new OpenROADDate((1L << 63) - 1);
    
    /**
     * <pre>
     * Description : Creates an <code>OpenROADDate</code> instance using the given milliseconds time value.
     *
     * @param date the date in milliseconds since January 1, 1970, 00:00:00 GMT not to exceed the 
     * milliseconds representation for the year 8099. A negative number indicates the number of 
     * milliseconds before January 1, 1970, 00:00:00 GMT.
     * </pre>
     */
    public OpenROADDate(final long date)
    {
        super(date);
    }
    
    
    /**
     * <pre>
     * Description : Creates an <code>OpenROADDate</code> instance that represents the date it 
     * was allocated.
     *
     * </pre>
     */
    public OpenROADDate()
    {
        super();
    }

    /**
     * <!-- ------------------------------------------------------------------------------------- -->
     * <!--
     * Method Name : isBlank
     * -->
     * <pre>
     * Description : Checks whether <code>this</code> instance represents the special OpenROAD blank date.
     *
     * @return true if this date represents the OpenROAD blank date, otherwise returns false.
     * </pre>
     * <!-- ------------------------------------------------------------------------------------- -->
     */
    public boolean isBlank()
    {
        return this.equals(BLANK_DATE);
    }
    
    /**
     * <!-- ------------------------------------------------------------------------------------- -->
     * <!--
     * Method Name : getBlankDate
     * -->
     * <pre>
     * Description : Provides an instance of <code>OpenROADDate</code> that represents a special 
     * blank date instance.
     *
     * @return an OpenROADDate instance representing a blank date.
     * </pre>
     * <!-- ------------------------------------------------------------------------------------- -->
     */
    public static OpenROADDate getBlankDate()
    {
        return BLANK_DATE;
    }
}
