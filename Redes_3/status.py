import subprocess
import json
import time
import pathlib

def getRAM():
	mem = {}
	result = subprocess.run(['free', '--si', '-m'], stdout=subprocess.PIPE)
	lines = result.stdout.decode('utf-8').split('\n')
	l1 = lines[0].split()
	l2 = lines[1].split()
	mem['RAM TOTAL'] = l2[1] 
	mem['RAM USED'] = l2[2]
	return mem
def subprocess_cmd(command):
	process = subprocess.Popen(command,stdout=subprocess.PIPE, shell=True)
	proc_stdout = process.communicate()[0].strip()
	return proc_stdout

def get_CPU():
	mem = {}
	cpu = {}
	result = subprocess_cmd('top -b -n1 | head -n 4').decode('utf-8')
	lines = result.split('\n')
	l0 = lines[0].split()
	l1 = lines[2].split()
	l2 = lines[3].split()
	time = []
	for i in l0[4:]:
		if i == 'user,': break
		time.append(i)
	time.pop()
	cpu['TIME OF EXECUTION'] = ' '.join(time)
	cpu['CPU USAGE %'] = l1[1] + l1[3]
	mem['RAM TOTAL'] = l2[3] 
	mem['RAM USED'] = l2[7]
	return {'CPU': cpu, 'RAM': mem}

if __name__ == "__main__":
	data = {}
	if not pathlib.Path('stats.json').is_file():
		json_file = open('stats.json', 'w')
		data['samples'] = [get_CPU()]
		json.dump(data, json_file, indent=4)
		json_file.close()
	while True:
		json_file = open('stats.json', 'r')
		data = json.load(json_file)
		size = len(data['samples'])
		if size == 100:
			data['samples'].pop(0)
		else:
			data['samples'].append(get_CPU())
		json_file.close()
		json_file = open('stats.json', 'w')
		json.dump(data, json_file, indent=4)
		json_file.close()
		time.sleep(5)