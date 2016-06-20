package com.fpt.contacts.service;

import java.util.List;

import com.fpt.contacts.dto.Contact;

/**
 * 
 * @author LuanTT
 *
 */
public interface ContactsService  
{
	/**
	 * Get contact by Id
	 * 
	 * @param id
	 * @return Contact
	 */
	public Contact getById(int id);

	/**
	 * Search contact by Name
	 * 
	 * @param name
	 * @return List<Contact>
	 */
	public List<Contact> searchContacts(String name);

	/**
	 * Get All Contact
	 * 
	 * @return List< Contact>
	 */
	public List<Contact> getAllContacts();

	/**
	 * Save contact
	 * 
	 * @param contact
	 * @return result
	 */
	public int save(Contact contact);

	/**
	 * Update contact
	 * 
	 * @param contact
	 */
	public void update(Contact contact);
	/**
	 * Delete contact
	 * @param id
	 */
	public void delete(int id);

}
