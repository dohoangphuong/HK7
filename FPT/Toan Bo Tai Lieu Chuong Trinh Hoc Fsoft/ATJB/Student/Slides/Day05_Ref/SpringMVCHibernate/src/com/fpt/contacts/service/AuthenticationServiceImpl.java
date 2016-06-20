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
 * Simple implementation of authentication service
 * 
 * @author LuanTT
 * 
 */
public class AuthenticationServiceImpl implements AuthenticationService
{

	private String			userName;
	private String			password;
	private boolean			logStatus;

	private final String	__USERNAME__	= "adrabi";
	private final String	__PASSWORD__	= "no-password";

	public boolean login()
	{
		return logStatus = userName.equals(__USERNAME__)
				&& password.equals(__PASSWORD__);
	}

	public boolean logout()
	{
		return !logStatus || (logStatus = false) || true;
	}

	public void password(String password)
	{
		this.password = password;
	}

	public void userName(String userName)
	{
		this.userName = userName;
	}

}
