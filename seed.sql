--
-- PostgreSQL database dump
--

-- Dumped from database version 14.2
-- Dumped by pg_dump version 14.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Data for Name: acl_actions; Type: TABLE DATA; Schema: public; Owner: user
--

INSERT INTO public.acl_actions (id, display_name, description) VALUES ('read_only_users', 'Read Only Users', 'You can only read stuff about users');
INSERT INTO public.acl_actions (id, display_name, description) VALUES ('write_users', 'Write Users', 'You can write on users');
INSERT INTO public.acl_actions (id, display_name, description) VALUES ('set_configurations', 'Set configurations', 'You can do some more staff');


--
-- Data for Name: roles; Type: TABLE DATA; Schema: public; Owner: user
--

INSERT INTO public.roles (id, display_name, description) VALUES ('admin', 'Admin', 'Super super role!');
INSERT INTO public.roles (id, display_name, description) VALUES ('user', 'User', 'Simple User');
INSERT INTO public.roles (id, display_name, description) VALUES ('dev', 'Dev', 'Superhero!');


--
-- Data for Name: role_aclaction; Type: TABLE DATA; Schema: public; Owner: user
--

INSERT INTO public.role_aclaction (role_id, acl_action_id) VALUES ('user', 'read_only_users');
INSERT INTO public.role_aclaction (role_id, acl_action_id) VALUES ('admin', 'read_only_users');
INSERT INTO public.role_aclaction (role_id, acl_action_id) VALUES ('dev', 'read_only_users');
INSERT INTO public.role_aclaction (role_id, acl_action_id) VALUES ('admin', 'write_users');
INSERT INTO public.role_aclaction (role_id, acl_action_id) VALUES ('dev', 'write_users');
INSERT INTO public.role_aclaction (role_id, acl_action_id) VALUES ('dev', 'set_configurations');


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: user
--

INSERT INTO public.users (id, firstname, lastname, username) VALUES ('81cc1b60-cbc6-4bac-9561-24ee17e1910b', 'Vincenzo', 'Carlino', 'v.carlino');
INSERT INTO public.users (id, firstname, lastname, username) VALUES ('15036a4c-de2a-46c1-9c84-5d106a8f0daf', 'Valentino', 'Rossi', 'v.rossi');
INSERT INTO public.users (id, firstname, lastname, username) VALUES ('459f6dde-3c89-4a26-906d-2be2cf444376', 'Dani', 'Pedrosa', 'd.pedrosa');


--
-- Data for Name: user_role; Type: TABLE DATA; Schema: public; Owner: user
--

INSERT INTO public.user_role (user_id, role_id) VALUES ('81cc1b60-cbc6-4bac-9561-24ee17e1910b', 'dev');
INSERT INTO public.user_role (user_id, role_id) VALUES ('15036a4c-de2a-46c1-9c84-5d106a8f0daf', 'admin');
INSERT INTO public.user_role (user_id, role_id) VALUES ('459f6dde-3c89-4a26-906d-2be2cf444376', 'user');


--
-- PostgreSQL database dump complete
--
