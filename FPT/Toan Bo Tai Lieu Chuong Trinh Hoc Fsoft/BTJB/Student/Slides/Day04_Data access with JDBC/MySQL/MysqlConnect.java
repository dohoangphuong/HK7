import java.sql.*;

public class MysqlConnect{
	public static void main(String[] args) {
		System.out.println("MySQL Connect Example.");
		Connection conn = null;
		String url = "jdbc:mysql://localhost:3306/";
		String dbName = "test";
		String driver = "com.mysql.jdbc.Driver";
		String userName = "testuser"; 
		String password = "testpass";
		try {
			Class.forName(driver).newInstance();
			conn = DriverManager.getConnection(url + dbName, userName, password);
			System.out.println("Connected to the database.");
		} catch (Exception e) {
			System.err.println("Cannot connect to database server.");
		} finally {
			if (conn != null) {
				try {
					conn.close ();
					System.out.println("Database connection terminated.");
				} catch (Exception e) { 
					/* ignore close errors */ 
				}
			}
		}
	}
}