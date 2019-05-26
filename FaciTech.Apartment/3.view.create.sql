CREATE  VIEW CommunityLocation 
AS
SELECT co.Id Id, 
	   co.Name Community ,
	   c.Id CountryId,
	   c.Name Country,
	   ci.Id CityId,
	   ci.Name City,
	   ar.Id AreaId,
	   ar.Name Area,
	   sa.Id SubAreaId,
	   sa.Name SubArea 
FROM Community co INNER JOIN SubArea sa on co.SubAreaId = sa.Id
INNER JOIN Area ar on ar.Id  = sa.AreaId
INNER JOIN City ci on ar.CityId = ci.Id
INNER JOIN Country c on ci.CountryId = c.Id