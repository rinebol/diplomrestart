create table OrderP
(
oid int primary key identity,
oname varchar(50),
oprovider varchar(50),
ocount int,
)
Drop table OrderP



Select oid, p.pname,c.tname,ocount, p.pcost from OrderP o inner join Product p on p.pid = o.oprovider inner join provider c on c.tid = p.pprovider