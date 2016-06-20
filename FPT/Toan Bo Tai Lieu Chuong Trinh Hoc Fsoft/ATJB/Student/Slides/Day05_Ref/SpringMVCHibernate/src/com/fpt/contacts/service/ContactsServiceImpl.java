package com.fpt.contacts.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;

import com.fpt.contacts.dao.ContactsDao;
import com.fpt.contacts.dto.Contact;

/**
 * 
 * @author LuanTT
 * 
 */

public class ContactsServiceImpl implements ContactsService {
	@Autowired
	private ContactsDao contactsDao;

	/**
	 * Get Contacts by ID
	 */
	public Contact getById(int id) {
		return (Contact) contactsDao.getById(id);
	}

	/**
	 * Search Contacts
	 */
	public List<Contact> searchContacts(String name) {
		return contactsDao.searchContacts(name);
	}

	/**
	 * Get All Contacts
	 */
	public List<Contact> getAllContacts() {
		return contactsDao.getAllContacts();
	}

	public ContactsDao getContactsDao() {
		return contactsDao;
	}

	public void setContactsDao(ContactsDao contactsDao) {
		this.contactsDao = contactsDao;
	}

	/**
	 * Save Contacts
	 */
	public int save(Contact contact) {
		return (Integer) contactsDao.save(contact);
	}

	/**
	 * Update Contact
	 */
	public void update(Contact contact) {
		contactsDao.update(contact);
	}

	/**
	 * Delete Contact
	 */
	public void delete(int id) {
		contactsDao.delete(id);
	}

}
