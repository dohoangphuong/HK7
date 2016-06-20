/**
 * A tutorial for Article Starting! Spring Aspect Oriented Object.
 * 
 * Author	: LuanTT
 * E-mail	: luantt@fsoft.com.vn
 * Year		: 2014
 * 
 */
package com.fpt.contacts.aop.authority;

/**
 * Authentication Service P Pointcuts
 * @author LuanTT
 *
 */
public class AuthenticationServicePointcuts
{

	/**
	 * Pointcut for methods userName() or password()
	 */
	public void afterUsernameOrPassword()
	{
		System.out.println("*** username or password method has exected ***");
	}

	/**
	 * Pointcut for method logout
	 */
	public void afterLogout()
	{
		System.out.println("*** you've logout now! see you later, bye! ***");
	}
}
