package vn.aptech;

import jakarta.servlet.ServletConfig;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.MultipartConfig;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.Part;

import java.io.File;
import java.io.IOException;
import java.io.PrintWriter;

import org.apache.tomcat.jakartaee.commons.lang3.text.StrBuilder;

/**
 * Servlet implementation class PoccessCustomer
 */
@MultipartConfig(fileSizeThreshold = 1024 * 1024,maxFileSize = 5 * 1024 * 1024,maxRequestSize = 5*5*1024*1024)
public class PoccessCustomer extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public PoccessCustomer() {
        super();
        // TODO Auto-generated constructor stub
    }
    private boolean isMultipart;
    private String filePath;
    private int maxFileSize = 50 * 1024;
    private int maxMemSize = 4 * 1024;
    private File file ;
    @Override
    public void init(ServletConfig config) throws ServletException {
    	// TODO Auto-generated method stub
    	super.init(config);
    	String name = config.getInitParameter("name");
    	log(name);
    }
	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		response.getWriter().append("Served at: ").append(request.getContextPath());
	}
	public String GetFileName(Part part) {
		String res = null;
		String header = part.getHeader("content-disposition");
		for(var s : part.getHeaderNames()) {
			log(s);
		}
		for(String name : header.split(";")) {
			if(name.trim().startsWith("filename")) {
				res = name.substring(name.indexOf("="),name.length()-1);
			}
		};
		log(part.getHeader("content-disposition"));
		return res;
	}
	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		response.setContentType("text/html; charset=UTF-8");
		//Chuan bi thu muc chua hinh
		String filename = null;
		String imgFolderPath = request.getServletContext().getRealPath("");
		File imgfolder = new File(imgFolderPath);
		if(!imgfolder.exists()) {
			imgfolder.mkdir();
		}
		
		for (Part part : request.getParts()) {
			filename = GetFileName(part);
			log(filename);
			if(filename!=null) {
				part.write(imgFolderPath+File.separator+filename);
			}
		}
		try(PrintWriter out = response.getWriter()){
			out.println("<html>");
			out.println("<heade>");
			out.println("<title>Customer Information</title>");
			out.println("</header>");
			out.println("<body>");
			out.println("<h1>Customer information</h1>");
			String name = request.getParameter("name");
			String email = request.getParameter("email");
			String gender= request.getParameter("gender");
			String sGender = gender.equals("1")? "Male": "Female";
			String[] hobbies = request.getParameterValues("hobbies");
			String sHobby = String.join(", ", hobbies);
			
			request.setAttribute("name", name);
			request.setAttribute("email", email);
			request.setAttribute("gender", sGender);
			request.setAttribute("hobby", sHobby);
			request.getRequestDispatcher("result.jsp").forward(request, response);
			StringBuilder sb = new StringBuilder();
			sb.append("Name: ").append(name).append("<br/>");
			sb.append("Email: ").append(email).append("<br/>");
			sb.append("Gender: ").append(sGender).append("<br/>");
			sb.append("Hobbies: ").append(sHobby).append("<br/>");
			out.println(sb.toString());
			out.println("</body>");
			out.println("</html>");
		}
	}

}
