<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</head>
<body>
	<div class="container">
		<div class="row">
			<h1 class="text-center mt-3">Customer</h1>
			<div class="col-8 mx-auto mt-3">
				<form method="post" class="w-100" action="PoccessCustomer" enctype="multipart/form-data">
					<div class="mb-3 row">
						<label class="col-3 col-form-label" for="name">Name</label>
						<div class="col-9">
							<input type="text" name="name" id="name" class="form-control" placeholder="Enter name" required="required"/>
						</div>
					</div>
					<div class="mb-3 row">
						<label class="col-3 col-form-label" for="email">Email</label>
						<div class="col-9">
							<input type="email" name="email" id="email" class="form-control" placeholder="Enter email" />
						</div>
					</div>
					<div class="mb-3 row">
						<label class="col-3 col-form-label" >Gender</label>
						<div class="col-9 ">
							<div class="col-3 form-check form-check-inline">
								<input type="radio" name="gender" id="male" value="1" class="form-check-input" />
								<label for="male" class="form-check-label">Male</label>
							</div>
							<div class="col-3 form-check form-check-inline">
								<input type="radio" name="gender" id="female" value="0" class="form-check-input" />
								<label for="female" class="form-check-label">Female</label>
							</div>
						</div>
					</div>
					<div class="mb-3 row">
						<label class="col-3 col-form-label" >Hobbies</label>
						<div class="col-9 ">
							<div class="col-3 form-check form-check-inline">
								<input type="checkbox" name="hobbies" id="shopping" value="shopping" class="form-check-input" />
								<label for="shopping" class="form-check-label">Shopping</label>
							</div>
							<div class="col-3 form-check form-check-inline">
								<input type="checkbox" name="hobbies" id="game" value="play game" class="form-check-input" />
								<label for="game" class="form-check-label">Play game</label>
							</div>
							<div class="col-3 form-check form-check-inline">
								<input type="checkbox" name="hobbies" id="swimming" value="swimming" class="form-check-input" />
								<label for="swimming" class="form-check-label">Swimming</label>
							</div>
						</div>
					</div>
					<div class="mb-3 row">
						<label class="col-3 col-form-label" >Photo</label>
						<div class="col-9 ">
							<input type="file" name="photo" class="form-control"/>
						</div>
					</div>
					<div class="mb-3 row">
						<input type="submit" value="Create" class="btn btn-primary col-3 mx-auto" />
					</div>
				</form>
			</div>
		</div>
	</div>
</body>
</html>