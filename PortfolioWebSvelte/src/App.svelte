<script>
	let name = "Lorem Ipsums";
	let API_URL = "https://localhost:7055/";
	let loremIpsums = [];

	function getLoremIpsums(){
		fetch(API_URL + "api/LoremIpsum")
			.then(response => response.json())
			.then(data => {
				console.log(data);
				loremIpsums = data;
			})
		}

	import {onMount} from 'svelte';

	onMount(async() => {
		getLoremIpsums();
	});
</script>

<main>
	<h2>{name}</h2>

	<table>
		{#each loremIpsums as ipsum}
			<tr>
				<td>{ipsum.name}</td>
				<td>{ipsum.value}</td>
			</tr>
		{/each}		
	</table>
</main>

<style>
	main {
		text-align: center;
		padding: 1em;
		max-width: 240px;
		margin: 0 auto;
	}

	@media (min-width: 640px) {
		main {
			max-width: none;
		}
	}
</style>