var url = 'http://localhost:4545';
var data = {
		username: 'example',
		tel: null,
		dir: null,
		com: null
	};

function clean() {
	document.getElementById('first_name').value = '';
	document.getElementById('tel').value = '';
	document.getElementById('Dir').value = '';
	document.getElementById('textarea1').value = '';
}

function send() {
	data.username = document.getElementById('first_name').value;
	data.tel = document.getElementById('tel').value;
	data.dir = document.getElementById('Dir').value;
	data.com = document.getElementById('textarea1').value;
	fetch(url, {
		method: 'POST', // or 'PUT'
		body: JSON.stringify(data), // data can be `string` or {object}!
		headers:{
		  'Content-Type': 'application/json'
		}
	  }).then(res =>{
		  return res.text();
	  })
	  .catch(error => console.error('Error:', error))
	  .then(response => {
				console.log('Success:', response);
				response = JSON.parse(response);
				document.getElementById('Bienvenido').style.display = 'none';
				posArea = document.getElementById('POST');
				posArea.style.display = 'block';
				mesg = document.createElement('div');
				mesg.classList.add('container', 'row');
				mesg.innerHTML = `
					<h1 class="center-align">Petición Post</h1>
					<div class="row">
						<div class="col s12">
							<div class="card">
								<div class="card-image">
									<img src="coddessB.png" width="400px"  height="auto">
									<span class="card-title"> <p style="background-color: crimson; padding: 0  2px 0 2px">${response.username} </p></span>
								</div>
								<div class="card-content">
									<p>
										Telefono: ${response.tel}<br>
										Dirección: ${response.dir}<br>
										Comentario: ${response.com}<br>
									</p>
								</div>
									<div class="card-action">
									<a href="/">Return</a>
								</div>
							</div>
						</div>
					</div> `;
				posArea.appendChild(mesg);
			});
}

function deleteF() {
	fetch(url, {
		method: 'DELETE',
		body: JSON.stringify({file: document.getElementById('file').value}), // data can be `string` or {object}!
		headers:{
		  'Content-Type': 'application/json'
		}
	  }).then(res =>{
		  return res.text();
	  })
	  .catch(error => console.error('Error:', error))
	  .then(response => {console.log('Success:', response);});
}

function getFiles(params) {
	fetch(url, {
		method: 'POST', // or 'PUT'
		body: 'file:all', // data can be `string` or {object}!
		headers:{
		  'Content-Type': 'application/json'
		}
	  }).then(res =>{
		  return res.text();
	  })
	  .catch(error => console.error('Error:', error))
	  .then(response => {
				console.log('Success:', response);
				document.getElementById('Files').innerHTML = `${response}`;
			});
}