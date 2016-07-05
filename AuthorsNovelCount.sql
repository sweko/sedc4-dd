Create view AuthorsNovelCount
as
select a.ID, a.Name, a.DateOfBirth, a.DateOfDeath, count(*) as NovelCount
from Authors a
inner join Novels n on a.ID = n.AuthorID
group by a.ID, a.Name, a.DateOfBirth, a.DateOfDeath

