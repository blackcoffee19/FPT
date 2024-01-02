package vn.aptech;

public class LoginCore {
	public boolean checkLogin(String u,String p) {
		return "aptech".equals(u) && "123".equals(p);
	}
}
