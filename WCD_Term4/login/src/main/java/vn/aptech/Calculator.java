package vn.aptech;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

/**
 * Servlet implementation class Calculator
 */
public class Calculator extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public Calculator() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		response.getWriter().append("Served at: ").append(request.getContextPath());
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		Double num1 = Double.parseDouble(request.getParameter("num1"));
		Double num2 = Double.parseDouble(request.getParameter("num2"));
		String method = request.getParameter("method");
		Double result = 0.0;
		if(method!=null) {
			switch (method) {
				case "+":
					result = num1+num2;
					break;
				case "-":
					result = num1-num2;
					break;
				case "x":
					result = num1*num2;
					break;
				case ":":
					result = num1/num2;
					break;
			}
		}
		PrintWriter out = response.getWriter();
		out.print(String.format("<html><head><title>Result</title></head><body><h1>Result %.2f %s %.2f = %.2f.</h1></body></html>",num1,method,num2,result));
	}

}
