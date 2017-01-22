select op.Name--, opr.ArgumentCount, opr.OperationId, opr.Result
from OperationResult as opr
join Operation as op ON op.Id = opr.OperationId
Group BY op.Name
having AVG(opr.ExecTimeMs) > 1000000