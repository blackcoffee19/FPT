package vn.aptech;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.Cookie;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;

import java.io.IOException;

/**
 * Servlet implementation class ProcessLogin
 */
public class ProcessLogin extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public ProcessLogin() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		response.sendError(403);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		String user = request.getParameter("user");
		String password = request.getParameter("password");
		HttpSession session = request.getSession();
		LoginCore core = new LoginCore();
		if(checkLogin(user,password)) {
			//lưu session
			session.setAttribute("user", user);
			//đọc parameter remember
			String remember = request.getParameter("remember");
			if(remember != null) {
				Cookie uCookie = new Cookie("user",user);
				Cookie pCookie = new Cookie("password",password);
				uCookie.setMaxAge(24*60*60);
				pCookie.setMaxAge(24*60*60);
				response.addCookie(uCookie);
				response.addCookie(pCookie);			
						
			}else { // xóa cookie
				Cookie uCookie = new Cookie("user",user);
				Cookie pCookie = new Cookie("password",password);
				uCookie.setMaxAge(0);
				pCookie.setMaxAge(0);
				response.addCookie(uCookie);
				response.addCookie(pCookie);
				
				
			}
			response.sendRedirect("index.jsp");
		}else {
			response.sendRedirect("loginError.jsp");
		}
	}
	private boolean checkLogin(String u, String p) {
		return "aptech".equals(u) && "123".equals(p);
	}
}
