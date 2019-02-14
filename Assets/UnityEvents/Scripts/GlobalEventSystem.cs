﻿using System;
using UnityEventsInternal;

namespace UnityEvents
{
	/// <summary>
	/// A system that handles global events for Fixed Update. Intended for gameplay events.
	/// </summary>
	public static class GlobalEventSystem
	{
		private static EventEntity _globalEntity;

		static GlobalEventSystem()
		{
			_globalEntity = EventEntity.CreateEntity();
		}

		/// <summary>
		/// Subscribe a listener to the global event system.
		/// </summary>
		/// <param name="callback">The callback that's invoked when an event occurs.</param>
		/// <typeparam name="T_Event">The event type.</typeparam>
		public static void Subscribe<T_Event>(Action<T_Event> callback) where T_Event : unmanaged
		{
			EventManager.Subscribe(_globalEntity, callback, EventUpdateType.FixedUpdate);
		}
	
		/// <summary>
		/// Subscribe a job to the global event system.
		/// </summary>
		/// <param name="job">The job that is processed when an event occurs.</param>
		/// <param name="onComplete">The callback that's invoked when the job is done.</param>
		/// <typeparam name="T_Job">The job type.</typeparam>
		/// <typeparam name="T_Event">The event type.</typeparam>
		public static void SubscribeWithJob<T_Job, T_Event>(T_Job job, Action<T_Job> onComplete) 
			where T_Job : struct, IJobForEvent<T_Event> 
			where T_Event : unmanaged
		{
			EventManager.SubscribeWithJob<T_Job, T_Event>(_globalEntity, job, onComplete, EventUpdateType.FixedUpdate);
		}

		/// <summary>
		/// Unsubscribe a listener from the global event system.
		/// </summary>
		/// <param name="callback">The callback to unsubscribe.</param>
		/// <typeparam name="T_Event">The event type.</typeparam>
		public static void Unsubscribe<T_Event>(Action<T_Event> callback) where T_Event : unmanaged
		{
			EventManager.Unsubscribe(_globalEntity, callback, EventUpdateType.FixedUpdate);
		}
	
		/// <summary>
		/// Unsubscribe a job from the global event system.
		/// </summary>
		/// <param name="onComplete">The on complete callback to unsubscribe</param>
		/// <typeparam name="T_Job">The job type to unsubscribe.</typeparam>
		/// <typeparam name="T_Event">The event type.</typeparam>
		public static void UnsubscribeWithJob<T_Job, T_Event>(Action<T_Job> onComplete) 
			where T_Job : struct, IJobForEvent<T_Event> 
			where T_Event : unmanaged
		{
			EventManager.UnsubscribeWithJob<T_Job, T_Event>(_globalEntity, onComplete, EventUpdateType.FixedUpdate);
		}

		/// <summary>
		/// Send an event to the global event system.
		/// </summary>
		/// <param name="ev">The event to send.</param>
		/// <typeparam name="T_Event">The event type.</typeparam>
		public static void SendEvent<T_Event>(T_Event ev) where T_Event : unmanaged
		{
			EventManager.SendEvent(_globalEntity, ev, EventUpdateType.FixedUpdate);
		}
	}
}
