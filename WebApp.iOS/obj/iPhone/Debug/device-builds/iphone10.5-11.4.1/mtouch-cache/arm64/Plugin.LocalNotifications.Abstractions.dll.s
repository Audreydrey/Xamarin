.subsections_via_symbols
.text
	.align 3
jit_code_start:

	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
.text
	.align 3
jit_code_end:

	.byte 0,0,0,0
.text
	.align 3
method_addresses:
	.no_dead_strip method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
method_addresses_end:

.section __TEXT, __const
	.align 3
unbox_trampolines:
unbox_trampolines_end:

	.long 0
.text
	.align 3
unbox_trampoline_addresses:

	.long 0
.section __TEXT, __const
	.align 3
unwind_info:

.text
	.align 4
plt:
mono_aot_Plugin_LocalNotifications_Abstractions_plt:
plt_end:
.section __DATA, __bss
	.align 3
.lcomm mono_aot_Plugin_LocalNotifications_Abstractions_got, 200
got_end:
.section __TEXT, __const
	.align 3
Lglobals_hash:

	.short 11, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0
.data
	.align 3
globals:
	.align 3
	.quad Lglobals_hash

	.long 0,0
.section __TEXT, __const
	.align 2
runtime_version:
	.asciz ""
.section __TEXT, __const
	.align 2
assembly_guid:
	.asciz "63DEDB58-FB98-45D5-87FD-F87CA30CE74E"
.section __TEXT, __const
	.align 2
assembly_name:
	.asciz "Plugin.LocalNotifications.Abstractions"
.data
	.align 3
_mono_aot_file_info:

	.long 149,0
	.align 3
	.quad mono_aot_Plugin_LocalNotifications_Abstractions_got
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad jit_code_start
	.align 3
	.quad jit_code_end
	.align 3
	.quad method_addresses
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad mem_end
	.align 3
	.quad assembly_guid
	.align 3
	.quad runtime_version
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad globals
	.align 3
	.quad assembly_name
	.align 3
	.quad plt
	.align 3
	.quad plt_end
	.align 3
	.quad unwind_info
	.align 3
	.quad unbox_trampolines
	.align 3
	.quad unbox_trampolines_end
	.align 3
	.quad unbox_trampoline_addresses

	.long 24,200,1,4,0,70,387000831,0
	.long 297,128,8,8,8,9,8388607,0
	.long 24,752,448,328,176,0,280,304
	.long 232,0,168,24,440,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0,0,0,0
	.byte 23,161,46,110,174,62,108,48,251,37,254,52,78,159,128,33
	.globl _mono_aot_module_Plugin_LocalNotifications_Abstractions_info
	.align 3
_mono_aot_module_Plugin_LocalNotifications_Abstractions_info:
	.align 3
	.quad _mono_aot_file_info
.text
	.align 3
mem_end:
