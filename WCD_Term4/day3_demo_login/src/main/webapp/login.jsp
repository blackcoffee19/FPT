<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<h1>Login</h1>

	<form action="ProcessLogin" method="post">
		<div>User: </div>
		<input name="user"/>
		<div>Password: </div>
		<input name="password"/>
		<div>
			<input type="checkbox" name="remember" value="1" id="remember"/>
			<label for="remember">Remember Me?</label>
		</div>
		<div>
			<input type="submit" value="Login"/>
		</div>
	</form>
</body>
</html>