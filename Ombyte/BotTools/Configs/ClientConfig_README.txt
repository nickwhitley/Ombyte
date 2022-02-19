

-------------- Gateway Intents:

As of Discord API v9, GatewayIntents must be specified in the socket config.
Intents allow your bot to do more things.

Common intents:
	- AllUnprivileged: This is a group of most common intents, that do NOT require any developer portl intents to be enabled.
			This includes intents that receive messages such as: GatewayIntents.GuildMessages, GatewayIntents.DirectMessages
	- GuildMembers: An intent disabled by default, as you need to enable it in the developer portal.
	- GuildPresence: Also disabled by default, this intent together with GuildMembers are the only intents not included in
			AllUnprivileged.
	- All: All intents, it is ill advised to use this without care, as it can cause a memory leak from presence.

List of all gateway intents:
	https://discordnet.dev/api/Discord.GatewayIntents.html

Stacking intents(use multiple intents):
	GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.GuildMembers | ...

--------------

