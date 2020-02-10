#/*******************************
# * 
# * Autor: Andrés Rodarte López
# *	Programa para ejecutar más rapido los nodos 
# * Del programa DistributedMatrixMul 
# * Es muy lento
# * 
# *******************************/
from multiprocessing import Pool
from multiprocessing.dummy import Pool as ThreadPool 
from subprocess import Popen, PIPE, call


cmds = ["java DistributedMatrixMul 4","java DistributedMatrixMul","java DistributedMatrixMul", "java DistributedMatrixMul"]
def function_create_cmds(cmd):
    proc = Popen(cmd , shell=True, stdout=PIPE, stderr=PIPE)
    (output, error) = proc.communicate()
    return output

# Make the Pool of workers
pool = ThreadPool(4)
results = pool.map(function_create_cmds, cmds)
#close the pool and wait for the work to finish 
pool.close() 
pool.join() 
for each in results:
	each = each.decode("utf-8")
	if len(each) > 0:
		print("out: {}\n".format(each))