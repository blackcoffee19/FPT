<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<div class="container">
		<div class="row">
			<h1 class="text-center mt-3">Customer Information</h1>
			<div class="col-8 mx-auto mt-3">
				<p>Customer name: <%= request.getAttribute("name") %></p>
				<p>Email: ${email}</p> 
				<p>Gender: ${gender}</p>
				<p>Hobbies: ${hobby}</p>
			</div>
		</div>
	</div>
	<%-- <%@include file="footer.jsp" %> --%>
	<%-- <% request.getRequestDispatcher("/footer.jsp").include(request, response); %> --%>
	<jsp:include page="/footer.jsp"></jsp:include>
</body>

</html>