<%@page import="vn.aptech.LoginCore"%>
<%@page import="jakarta.websocket.Session"%>
<%@ page import="jakarta.servlet.http.Cookie" %>

<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<%
	if(session.getAttribute("user") == null){
		String u = null;
		String p = null;
		for(Cookie c: request.getCookies()){
			if (c.getName().equals("user")){
				u = c.getValue();
			}else if(c.getName().equals("password")){
				p = c.getValue();
			}
		}
		if(u!=null && p!=null){
			LoginCore core = new LoginCore();
			if(core.checkLogin(u, p)){
				session.setAttribute("user", u);
			}else{
				response.sendRedirect("login.jsp");
			}
		}else{
			response.sendRedirect("login.jsp");
		}
	}
%>
	<h1>Hello mấy ní</h1>
	<h3>Welcome ${user}</h3>
</body>
</html>