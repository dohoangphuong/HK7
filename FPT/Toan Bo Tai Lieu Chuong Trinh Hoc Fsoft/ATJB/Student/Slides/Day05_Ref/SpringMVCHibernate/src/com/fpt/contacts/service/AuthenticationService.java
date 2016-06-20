/**
 * A tutorial for Article Starting! Spring Aspect Oriented Object.
 * 
 * Author	: LuanTT
 * E-mail	: luantt@fsoft.com.vn
 * Year		: 2014
 * 
 */
package com.fpt.contacts.service;

/**
 * Authentication service
 * @author LuanTT
 *
 */
public interface AuthenticationService
{
	/**
	 * Setting a user name for authentication
	 * 
	 * @param userName
	 */
	public void userName(String userName);

	/**
	 * Setting a password for authentication
	 * 
	 * @param password
	 */
	public void password(String password);

	/**
	 * Try to log-in
	 * 
	 * @return
	 */
	public boolean login();

	/**
	 * Try to log-out
	 * 
	 * @return
	 */
	public boolean logout();
}
