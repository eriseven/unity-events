﻿using UnityEventsInternal;

namespace UnityEvents.Test
{
	public struct EvSimpleEvent
	{
		public int value;

		public EvSimpleEvent(int value)
		{
			this.value = value;
		}
	}

	public struct EvSimpleEvent2
	{
		public int value;

		public EvSimpleEvent2(int value)
		{
			this.value = value;
		}
	}

	public struct TestJob : IJobForEvent<EvSimpleEvent>
	{
		public int result;

		public TestJob(int result)
		{
			this.result = result;
		}

		public void ExecuteEvent(EvSimpleEvent ev)
		{
			result += ev.value;
		}
	}

	public struct TestJob2 : IJobForEvent<EvSimpleEvent2>
	{
		public int result;

		public TestJob2(int result)
		{
			this.result = result;
		}

		public void ExecuteEvent(EvSimpleEvent2 ev)
		{
			result += ev.value;
		}
	}

	public struct TestResetJob : IJobForEvent<EvSimpleEvent>
	{
		public int result;

		public TestResetJob(int result)
		{
			this.result = result;
		}

		public void ExecuteEvent(EvSimpleEvent ev)
		{
			result = 0;
			result += ev.value;
		}
	}
}