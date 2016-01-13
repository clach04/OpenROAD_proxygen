/**
 * Copyright Luminary Solutions Limited
 *
 */
package uk.co.luminary.proxygen.util;

import com.ca.openroad.*;

/**
 * <!-- ----------------------------------------------------------------------------------------- -->
 * <pre>
 * Description     : The interface used by all proxies which wrap an OpenROAD class.
 * <!--
 * Interface       : uk.co.luminary.proxygen.util.OpenROADClass
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
public interface OpenROADClass {
    /**
     * <!-- ------------------------------------------------------------------------------------- -->
     * <!--
     * Method Name : declareAttributes
     * -->
     * <pre>
     * Description : Declare the attributes of this class on the given paramater object.
     *
     * @param pdo, the parameter object to declare the attributes on
     * @param name, the name of this class in your OpenROAD application
     * </pre>
     * <!-- ------------------------------------------------------------------------------------- -->
     */
    void declareAttributes(ParameterData byref, String name) throws COMException;
    /**
     * <!-- ------------------------------------------------------------------------------------- -->
     * <!--
     * Method Name : setAttributes
     * -->
     * <pre>
     * Description : Set the attributes of this class on the given paramater object.
     *
     * @param pdo, the parameter object to set the attributes on
     * @param name, the name of this class in your OpenROAD application
     * </pre>
     * <!-- ------------------------------------------------------------------------------------- -->
     */
    void setAttributes(ParameterData byref, String name) throws COMException;
    /**
     * <!-- ------------------------------------------------------------------------------------- -->
     * <!--
     * Method Name : populateAttributes
     * -->
     * <pre>
     * Description : Repopulate this object from the given parameter object.
     *
     * @param pdo, the parameter object to get the attributes from to repopulate this object
     * @param name, the name of this class in your openroad application
     * </pre>
     * <!-- ------------------------------------------------------------------------------------- -->
     */
    void populateAttributes(ParameterData byref, String name) throws COMException;
}
