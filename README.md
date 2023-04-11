# DAEA_S4

select * from Person

alter PROC USP_GetPeople
@LastName Varchar(20) = '',
@FirstName Varchar(20) = ''
AS
BEGIN
SELECT * FROM Person
WHERE (@FirstName LIKE '%'+first_name+'%' OR @FirstName ='') 
AND (@LastName LIKE '%' +last_name+'%' OR @LastName ='')
END

USP_GetPeople

insert into Person (id, last_name, first_name, full_name, age) values ('12', 'Luis', 'Antonio', 'Carrillo Ventura', 42)
